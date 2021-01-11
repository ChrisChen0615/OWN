(($) => {
    "use strict";

    var query = {
        init: () => {
            $('#btnQuery', '#formQuery').on('click', () => {
                $.ajax({
                    url: '/Paging/Address',
                    async: true,
                    dataType: 'html'
                }).done(function (result) {
                    var form = $('#resultQuery');
                    form.append(result);
                }).always(() => {
                });
            })

            $('#resultQuery').on('click', '#btnPrev,#btnNext', (e) => {
                var target = $(e.target);
                var num = $(target).data('pagenumber');
                debugger;
                num = num ? num : 1;
                $.ajax({
                    url: '/Paging/Address',
                    async: true,
                    dataType: 'html',
                    data: { pageNumber: num }
                }).done(function (result) {
                    var form = $('#resultQuery');
                    form.empty();
                    form.append(result);
                }).always(() => {
                });
            });

            //$("#example").DataTable({
            //    searching: false, //關閉filter功能
            //    columnDefs: [{
            //        targets: [3],
            //        orderable: false,
            //    }]
            //});
            $("#example").DataTable({
                "processing": true, // for show progress bar    
                "serverSide": true, // for process server side    
                "filter": true, // this is for disable filter (search box)    
                "orderMulti": false, // for disable multiple column at once    
                "ajax": {
                    "url": "/Paging/Address",
                    "type": "POST",
                    "datatype": "json"
                },
                "columnDefs": [{
                    "targets": [0],
                    "visible": false,
                    "searchable": false
                }],
                "columns": [
                    { "data": "addressLine1", "name": "AddressLine1", 'title': "AddressLine1", "autoWidth": true },
                    { "data": "city", "name": "City", 'title': "City", "autoWidth": true },
                    { "data": "stateProvince", "name": "StateProvince", 'title': "StateProvince", "autoWidth": true },
                    { "data": "countryRegion", "name": "CountryRegion", 'title': "CountryRegion", "autoWidth": true },
                    { "data": "postalCode", "name": "PostalCode", 'title': "PostalCode", "autoWidth": true },
                    {
                        "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/DemoGrid/Edit/' + full.CustomerID + '">Edit</a>'; }
                    },
                    {
                        data: null,
                        render: function (data, type, row) {
                            return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.CustomerID + "'); >Delete</a>";
                        }
                    },
                ]
            });
        }
    };

    $(document).ready(function () {
        query.init();
    });
})($);