
var http = require('http');
var bids = [];
var viewModel = {
  
    bids: ko.observableArray(bids),
    addOffUrl: "home/AddOffer",
    addBidUrl: "home/AddBid"
};

var method;
$(function() {

    http.get('api/Bid/GetBidsByTopTenOffered').then(function(response) {
        handleResponse(response);
    });


    $('#nav > li > a').click(function() {

        switch ($(this).text()) {
        case 'Added':
            method = handleBuyingCategories;
            break;
        case 'Prices':
            method = handlePrices;
            break;
        case 'Condition':
            method = handleCondition;
            break;
        case 'Buying Format':
            method = handleBuyingFormat;
            break;
        }
    });

    $('#nav > li > ul > li > a').click(function() {
        return method($(this).text());
    });

 ko.applyBindings(viewModel);
});

function handleBuyingCategories(param) {
    switch (param) {
        case 'Yesterday':
            method = "GetBidsAddedYesterday";
            break;
        case 'Last week':
            method = "GetBidsAddedLastWeek";
            break;
        case 'Today':
            method = "GetBidsAddedToday";
            break;
    }
 
    http.get('api/Bid/' + method).then(function (response) {
        handleResponse(response);
    });
}

function handlePrices(param) {
    var substr = param.split('-');
    var data = { lowerLimit: substr[0].substring(1), upperLimit: substr[1] };

    http.get('api/Bid/GetBidsByPriceRange', data).then(function (response) {
        handleResponse(response);
    });

}

function handleCondition(param) {
    http.get('api/Bid/GetBidsByCondition', { 'condition': param }).then(function (response) {
        handleResponse(response);
    });

}


function handleBuyingFormat(param) {
    http.get('api/Bid/GetBidsByTransactionType', { 'transactionType': param }).then(function (response) {
        handleResponse(response);
    });
}

function handleResponse(response) {
    viewModel.bids.removeAll();
    $.each(response, function (key, val) {
        viewModel.bids.push(ko.mapping.fromJS(val));
    });
}