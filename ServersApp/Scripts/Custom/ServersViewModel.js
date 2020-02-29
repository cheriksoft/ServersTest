var ServersViewModel = {
    _listUrl: '',
    _createUrl: '',
    _deleteUrl: '',

    CurrentDateTime: ko.observable(''),
    TotalUsageTime: ko.observable(''),
    Servers: ko.observableArray([]),

    Init: function(listUrl, createUrl, deleteUrl) {
        this._listUrl = listUrl;
        this._createUrl = createUrl;
        this._deleteUrl = deleteUrl;

        this.ReloadServers();
    },
    ReloadServers: function() {
        AjaxGet(this._listUrl, {}, $.proxy(this.UpdateModel, this));
    },
    UpdateModel: function(data) {
        this.CurrentDateTime(data.CurrentDateTime);
        this.TotalUsageTime(data.TotalUsageTime);
        this.Servers(data.Servers);
    },
    GetServerIdsForRemove: function() {
        var result = [];

        for (var i = 0; i < this.Servers().length; i++) {
            var currentServer = this.Servers()[i];

            if (currentServer.SelectedForRemove) {
                result.push(currentServer.VirtualServerId);
            }
        }

        return result;
    },
    AddServer: function() {
        AjaxPost(this._createUrl, { }, $.proxy(this.UpdateModel, this));
    },
    RemoveSelectedServers: function() {
        var serverIds = this.GetServerIdsForRemove();

        if (serverIds.length == 0) {
            alert('Choose at least one server!');
        } else {
            if (confirm('Delete selected servers?')) {
                AjaxPost(this._deleteUrl, { ids: serverIds }, $.proxy(this.UpdateModel, this));
            };
        }
    }

};