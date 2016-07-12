//auto: tac
//desc: ace side bar navigator manager

var Sidebar = function ( appendTo) {
    var self = this;
    var menusList = new List();
    var $container = $(appendTo);

    //获取当前页面对应的menu
    this.GetCurrentMenu = function () {
        return $($container.find("li a[data-rpath='" + location.pathname + "']")[0]).parent("li");
    };

    //获取当前页面对应的menu
    this.GetMenuById = function (id) {
        return $($container.find("li[data-id=" + id + "]")[0]);
    };

    //生成sidebar
    this.AddMenus = function (menus) {
        var list = new List(menus.slice());
        menusList.add(menus);
        var times = 0;
        var max = 10; //最多执行10次后退出循环，防止一些菜单项找不到上级菜单而陷入死循环
        while (list.getArray().length > 0) {
            $.each(list.getArray(), function(index, item) {
                var $li = $("<li></li>");
                var $content = $("<a></a>");
                var $arrow = $("<b class='arrow'></b>");

                $li.attr("data-id", item.ID);
                $content.attr("href", item.Url);

                var rPath = item.Url.match(/(^[^\?]+)\?/g); //相对路径，用于选中当前页菜单
                rPath = rPath != null ? rPath[0].substr(0, rPath[0].length - 1) : item.Url;     //去年?号
                $content.attr("data-rpath", rPath);

                $content.append($("<i></i>").addClass(item.Icon))
                    .append($("<span></span>").addClass("menu-text").text(" " + item.Name + " "))
                    .append($arrow);

                $li.append($content);

                if (item.ParentId == null) {
                    //顶级菜单
                    $container.append($li);
                    list.removeBy("ID", item.ID); //从list中移除已经append到nav的菜单项
                } else {
                    //子菜单
                    var $parent = $("li[data-id=" + item.ParentId + "]");
                    if ($parent.length > 0) {
                        $($parent.children("a")[0]).attr("href", "#").addClass("dropdown-toggle")
                            .append($("<b class='arrow icon-angle-down'></b>"));
                        var $subMenu = $parent.children("ul.submenu");
                        if ($subMenu.length <= 0) {
                            $subMenu = $("<ul class='submenu'></ul>");
                            $parent.append($subMenu);
                        }

                        $subMenu.append($li);
                        list.removeBy("ID", item.ID); //从list中移除已经append到nav的菜单项
                    }
                }
            });
            times++;
            if (times > max) break;
        }
    };

    //打开指定菜单
    //isActivate: bool 是否要将菜单标识为active
    this.OpenMenu = function (id, isActivate) {
        var $now = self.GetMenuById(id);
        if (isActivate) {
            $now.addClass("active"); //选中当前菜单
        }

        var $menu = $now.parent("ul");
        var $p = $now.parent("ul").parent("li"); //父菜单li
        while ($p.length > 0) {
            if (isActivate) {
                $p.addClass("active");
            }
            $p.addClass("open");

            $menu.show();

            $now = $p;
            $menu = $now.parent("ul");
            $p = $now.parent("ul").parent("li");
        }
    };

    //折叠所有菜单
    //isActive: bool 是否要折叠active的菜单
    this.CollapseAllMenu = function(isActive) {
        if (isActive) {
            $container.find("li").removeClass("active open");
            $container.find(".submenu").hide();
        } else {
            var $topMenu = $container.children("li").not(".active").removeClass("open");
            $topMenu.find("li").removeClass("open");
            $topMenu.find(".submenu").hide();
        }
    };


    this.PointAtMenus = function() {
        throw Error("PointAtMenus(): Function is not implement");
    };
};