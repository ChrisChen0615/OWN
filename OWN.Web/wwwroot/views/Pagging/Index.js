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
            })
        }
    };

    $(document).ready(function () {
        query.init();
    });
})($);