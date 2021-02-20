(($) => {
    "use strict";

    var query = {
        form: {
            id: '#formQuery',
            get $elem() {
                return $(this.id);
            }
        },
        buttons: {
            btnQuery: {
                id: '#btnQuery',
                get $elem() {
                    return $(this.id);
                },
                init: () => {
                    $(query.buttons.btnQuery.id, query.form.id).on('click', () => {
                        if (query.dataTable.$table) {
                            query.dataTable.reload();
                        }
                        else {
                            query.dataTable.init();
                        }
                    });
                }
            },
            initEvent: () => {
                let bts = query.buttons;
                bts.btnQuery.init();
            }
        },
        dataTable: {
            id: '#tableQuery',
            get $elem() {
                return $(this.id);
            },
            init: () => {
                query.dataTable.$table = query.dataTable.$elem.DataTable({
                    serverSide: true,
                    paging: true,
                    ajax: {
                        url: "/Paging/Address",
                        type: "POST",
                        datatype: "json",
                        data: function (d) {
                            $.extend(d, query.form.$elem.serializeObject());
                            return d;
                        }
                    },
                    columns: [
                        { data: "addressLine1", name: "AddressLine1", title: "AddressLine1", autoWidth: true },
                        { data: "city", name: "City", title: "City", autoWidth: true },
                        { data: "stateProvince", name: "StateProvince", title: "StateProvince", autoWidth: true },
                        { data: "countryRegion", name: "CountryRegion", title: "CountryRegion", autoWidth: true },
                        { data: "postalCode", name: "PostalCode", title: "PostalCode", autoWidth: true },
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
            },
            reload: () => {
                query.dataTable.$table.ajax.reload();
            }
        },
        init: () => {
            query.buttons.initEvent();
        }
    };

    $(document).ready(function () {
        query.init();
    });
})($);