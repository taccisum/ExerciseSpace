//auto: tac
//desc: 封装datatabls插件，使用缺省参数将其封装成模板


(function ($) {
    function DefConfig() {
        this.ordering = false;
        this.processing = true;
        this.scrollX = true;
        this.filter = false;
        //thisstateSave= true;
        this.serverSide = true;
        this.language = {
            processing: "<p style='color:gray;'><i class='icon-spinner icon-spin'></i>正在玩命加载…</p>",
            lengthMenu: " _MENU_ ",
            zeroRecords: "对不起，查询不到相关数据！",
            emptyTable: "表中无数据存在！",
            info: "当前 _START_ ~ _END_ ，共 _TOTAL_ 条记录",
            infoFiltered: "数据表中共为 _MAX_ 条记录",
            search: "搜索",
            paginate: {
                "sFirst": "<i class='icon-fast-backward'></i>",
                "sPrevious": "<i class='icon-step-backward'></i>",
                "sNext": "<i class='icon-step-forward'></i>",
                "sLast": "<i class='icon-fast-forward'></i>"
            }
        };
    };       //默认配置


    $.fn.extend({
        datatables_proxy: function (config) {
            var $tables = $(this);
            $.each($tables, function (index, table) {
                var $table = $(table);
                var conf = $.extend(new DefConfig(), config);

                $table.DataTable(conf);
            });
        }
    });
})
(jQuery);


