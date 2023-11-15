var pageIndex = 1;
var pageSize = 10;
var totalPageCount = 0;
var maxPagesToShow = 25;
var sortOrder = "medallion";
var spanTotalEntites = $("#totalCount");
var apiUrls;

$(document).ready(function () {
    getApiUrls();
    $(document).on("click", ".pagination-link", function () {
        pageIndex = $(this).data("pageindex");
        sendRequest();      
    });
});

function getApiUrls() {
    $.ajax({
        type: "GET",
        url: "/api/Configuration/GetApiUrls",
        dataType: "json",
        success: function (data) {
            apiUrls = data;
            sendRequest();
        },
        error: function (error) {
            console.log("AJAX error: " + error);
        }
    });
}
function sortData(column) {
    if (sortOrder === column) {
        sortOrder += sortOrder.endsWith("Desc") ? "" : "Desc";
    } else {
        sortOrder = column;
    }
    $(".sort-arrows").removeClass("active-up active-down");
    
    $("#" + column + "SortArrows").addClass(sortOrder.endsWith("Desc") ? "active-down" : "active-up");
    pageIndex = 1;
    sendRequest();
}
function sendRequest(){
    $('#loadingSpinner').show();
    $('#tableContainer').hide();
    var searchParameter = $("#searchInput").val();
    if (searchParameter) 
        searchByMedallion(searchParameter);
    else
        loadData();
}
function loadData() {
    $.ajax({
        type: "GET",
        url: apiUrls.getPaged,
        data: {
            pageIndex: pageIndex,
            pageSize: pageSize,
            sortOrder: sortOrder
        },
        dataType: "json",
        success: function (data) {
            totalPageCount = data.totalPages;
            $('#loadingSpinner').hide();
            $('#tableContainer').show();
            var tableBody = $("#dataTable tbody");
            tableBody.empty();
            spanTotalEntites.text(data.totalEntites);
            $.each(data.data, function (index, item) {
                var row = $("<tr>")
                    .append($("<td>").text(item.medallion))
                    .append($("<td>").text(item.hackLicense))
                    .append($("<td>").text(item.vendorId))
                    .append($("<td>").text(item.rateCode))
                    .append($("<td>").text(item.storeAndFwdFlag))
                    .append($("<td>").text(item.pickupDatetime))
                    .append($("<td>").text(item.dropoffDatetime))
                    .append($("<td>").text(item.passengerCount))
                    .append($("<td>").text(item.tripTimeInSecs))
                    .append($("<td>").text(item.tripDistance))
                    .append($("<td>").text(item.pickupLongitude))
                    .append($("<td>").text(item.pickupLatitude))
                    .append($("<td>").text(item.dropoffLongitude))
                    .append($("<td>").text(item.dropoffLatitude))
                    .append($("<td>").text(item.paymentType))
                    .append($("<td>").text(item.fareAmount))
                    .append($("<td>").text(item.surcharge))
                    .append($("<td>").text(item.mtaTax))
                    .append($("<td>").text(item.tollsAmount))
                    .append($("<td>").text(item.totalAmount))
                    .append($("<td>").text(item.tipAmount))
                    .append($("<td>").text(item.tipped))
                    .append($("<td>").text(item.tipClass));
                tableBody.append(row);
            });

            renderPagination();
        },
        error: function (error) {
            console.log("AJAX error: " + error);
        }
    });
}
function renderPagination() {
    var paginationContainer = $("#pagination ul");
    paginationContainer.empty();

    var pageLinks = [];

    if (totalPageCount <= maxPagesToShow) {
        for (var i = 1; i <= totalPageCount; i++) {
            pageLinks.push($("<li class='page-item " + (i === pageIndex ? 'active' : '') + "'>")
                .append($("<a class='page-link pagination-link' href='#'>")
                    .text(i)
                    .data("pageindex", i)
                ));
        }
    } else {
        pageLinks.push($("<li class='page-item " + (pageIndex === 1 ? 'active' : '') + "'>")
            .append($("<a class='page-link pagination-link' href='#'>")
                .text(1)
                .data("pageindex", 1)
            ));

        if (pageIndex > 14) {
            pageLinks.push($("<li class='page-item disabled'>")
                .append($("<span class='page-link'>")
                    .text("...")
                ));
        }

        var startPage = Math.max(2, pageIndex - Math.floor(maxPagesToShow / 2));
        var endPage = Math.min(startPage + maxPagesToShow - 1, totalPageCount);

        for (var i = startPage; i <= endPage; i++) {
            pageLinks.push($("<li class='page-item " + (i === pageIndex ? 'active' : '') + "'>")
                .append($("<a class='page-link pagination-link' href='#'>")
                    .text(i)
                    .data("pageindex", i)
                ));
        }

        if (endPage < totalPageCount - 3) {
            pageLinks.push($("<li class='page-item disabled'>")
                .append($("<span class='page-link'>")
                    .text("...")
                ));
        }

        for (var i = Math.max(totalPageCount - 2, 2); i <= totalPageCount; i++) {
            pageLinks.push($("<li class='page-item " + (i === pageIndex ? 'active' : '') + "'>")
                .append($("<a class='page-link pagination-link' href='#'>")
                    .text(i)
                    .data("pageindex", i)
                ));
        }
    }

    paginationContainer.append(pageLinks);
}
function changePageSize() {
    pageSize = $("#pageSizeSelect").val();
    pageIndex = 1;
    sendRequest();
}
function searchByMedallion(searchParameter) {   
    $.ajax({
        type: "GET",
        url: apiUrls.searchWithPagedByMedallion,
        data: {
            pageIndex: pageIndex,
            pageSize: pageSize,
            sortOrder: sortOrder,
            searchParameter: searchParameter
        },
        dataType: "json",
        success: function (data) {
            totalPageCount = data.totalPages;
            var tableBody = $("#dataTable tbody");
            tableBody.empty();
            spanTotalEntites.text(data.totalEntites);
            $('#loadingSpinner').hide();
            $('#tableContainer').show();
            $.each(data.data, function (index, item) {
                var row = $("<tr>")
                    .append($("<td>").text(item.medallion))
                    .append($("<td>").text(item.hackLicense))
                    .append($("<td>").text(item.vendorId))
                    .append($("<td>").text(item.rateCode))
                    .append($("<td>").text(item.storeAndFwdFlag))
                    .append($("<td>").text(item.pickupDatetime))
                    .append($("<td>").text(item.dropoffDatetime))
                    .append($("<td>").text(item.passengerCount))
                    .append($("<td>").text(item.tripTimeInSecs))
                    .append($("<td>").text(item.tripDistance))
                    .append($("<td>").text(item.pickupLongitude))
                    .append($("<td>").text(item.pickupLatitude))
                    .append($("<td>").text(item.dropoffLongitude))
                    .append($("<td>").text(item.dropoffLatitude))
                    .append($("<td>").text(item.paymentType))
                    .append($("<td>").text(item.fareAmount))
                    .append($("<td>").text(item.surcharge))
                    .append($("<td>").text(item.mtaTax))
                    .append($("<td>").text(item.tollsAmount))
                    .append($("<td>").text(item.totalAmount))
                    .append($("<td>").text(item.tipAmount))
                    .append($("<td>").text(item.tipped))
                    .append($("<td>").text(item.tipClass));
                tableBody.append(row);
            });

            renderPagination();
        },
        error: function (error) {
            console.log("AJAX error: " + error);
        }
    });
}