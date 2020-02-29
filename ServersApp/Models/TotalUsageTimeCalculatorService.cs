using System;
using System.Collections.Generic;
using System.Linq;
using Datalayer.Entities;

namespace ServersApp.Models
{
    /// <summary>
    /// Подсчитаем общее время, когда в таблице был хоть один неудаленный сервер
    /// </summary>
    public class TotalUsageTimeCalculatorService : ITotalUsageTimeCalculatorService
    {
        public TimeSpan CalculateForServers(IEnumerable<VirtualServer> servers)
        {
            //Используем нечто типа map-reduce. Сначала соберем массив пар (время, изменение кол-ва серверов - +1 или -1)
            var timesMap = servers.Select(x => new Tuple<DateTime, short>(x.CreateDateTime, 1))
                .Concat(servers.Where(x => x.RemovedDateTime.HasValue)
                    .Select(x => new Tuple<DateTime, short>(x.RemovedDateTime.Value, -1))).OrderBy(x => x.Item1).ToArray();

            //Теперь пробежимся по массиву. Будем смотреть кол-во серверов в диапазонах времен и прибавлять время к результату, если оно больше 0
            var result = TimeSpan.Zero;
            var serversCount = 0;
            for (var i = 0; i < timesMap.Length; i++)
            {
                serversCount += timesMap[i].Item2;

                if (serversCount > 0)
                {
                    if (i < timesMap.Length - 1)
                    {
                        result += (timesMap[i + 1].Item1 - timesMap[i].Item1);
                    }
                    else
                    {
                        //Для последнего изменения отсчет ведем относительно текущего времени
                        //Для простоты будем считать, что серверов, созданных/удаленных в "будущем" у нас нету. Иначе получим веселые резульататы (типа отрицательного времени использования).
                        result += (DateTime.Now - timesMap[i].Item1);
                    }
                }
            }

            return result;
        }
    }
}