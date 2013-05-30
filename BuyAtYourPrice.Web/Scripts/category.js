var http = require('http');

function categoryViewModel() {
    var self = this;
    self.categories = ko.observableArray([]);
    http.get('/api/productcategory/get').then(function(response) {
        self.categories(response.AvailableProjects);
    });
    ko.applyBindings(viewModel);
}