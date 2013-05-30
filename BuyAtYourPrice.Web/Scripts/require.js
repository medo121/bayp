$(function() {
    var viewModel = {
        bids: ko.observableArray([]),

        addOffUrl: "home/AddOffer",
        addBidUrl: "home/AddBid"
    };
    $.ajax({
        url: 'api/Bid/GetBidsByTopTenOffered',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function(data) {
            $.each(data, function(key, val) {
                // viewModel.bids = [];
                viewModel.bids.push(ko.mapping.fromJS(val));
            });
        },
        error: function() {
            alert("error");
        }
    });

    var method ;
    $('#nav > li > a').click(function() {
        method = null;
       
        switch ($(this).text()) {      
        case 'Categories':
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


    function handleBuyingCategories(param) {
        var method;
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
        viewModel.bids = [],
        $.ajax({
            url: 'api/Bid/' + method,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            success: function(data) {
                $.each(data, function(key, val) {
                    viewModel.bids.push(ko.mapping.fromJS(val));
                });
            },
            error: function() {
                alert("error");
            }
        });        


    }

    function handlePrices(param) {

        var substr = param.split('-');
        var bidsByPriceRangeModel = { LowerLimit: substr[0].substring(1), UpperLimit: substr[1] };
        $.ajax({
            url: 'api/Bid/GetBidsByPriceRange',
            type: 'GET',
            data: bidsByPriceRangeModel,
            contentType: 'application/json; charset=utf-8',
            success: function(data) {
                $.each(data, function(key, val) {
                    viewModel.bids.push(ko.mapping.fromJS(val));
                });
            },
            error: function() {
                alert("error");
            }
        });

    }

    function handleCondition(param) {

        $.ajax({
            url: 'api/Bid/GetBidsByCondition',

            data: { 'condition': param },
            contentType: 'application/json; charset=utf-8',
            success: function(data) {
                $.each(data, function(key, val) {
                    viewModel.bids.push(ko.mapping.fromJS(val));
                });
            },
            error: function() {
                alert("error");
            }
        });
    }

    function handleBuyingFormat(param) {
        $.ajax({
            url: 'api/Bid/GetBidsByTransactionType',
            type: 'GET',
            data: { 'transactionType': JSON.stringify(param) },
            contentType: 'application/json; charset=utf-8',
            success: function(data) {
                $.each(data, function(key, val) {
                    viewModel.bids.push(ko.mapping.fromJS(val));
                });
            },
            error: function() {
                alert("error");
            }
        });
    }

    ko.applyBindings(viewModel);
});