//>>built
define("epi/cms/widget/_ContentListMouseMixin",["dojo/_base/declare","dojo/dom-class"],function(_1,_2){return _1("epi.cms.widget._ContentListMouseMixin",null,{onHover:function(_3){},onUnhover:function(_4){},onSelect:function(_5){_2.add(_5,"dgrid-selected ui-state-active dgrid-focus");},onDeselect:function(_6){_2.remove(_6,"dgrid-selected ui-state-active dgrid-focus");}});});