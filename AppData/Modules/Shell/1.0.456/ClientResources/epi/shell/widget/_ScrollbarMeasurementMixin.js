//>>built
define("epi/shell/widget/_ScrollbarMeasurementMixin",["dojo/_base/declare","dojo/_base/window","dojo/dom-construct","dojo/dom-style"],function(_1,_2,_3,_4){var _5=_1("epi.shell.widget._ScrollbarMeasurementMixin",[],{getScrollbars:function(_6){var _7=this.getScrollbarSize(),_8=_6.documentElement||_6,_9;function _a(_b,sb){if(_8){return {y:_8.scrollHeight>_8.clientHeight?_b.y:sb.y,x:_8.scrollWidth>_8.clientWidth?_b.x:sb.x};}return {x:0,y:0};};function _c(_d){var _e={x:0,y:0};if(_8){_4.get(_8,"overflow-y")==="scroll"?_e.y=_d.y:_e.y=0;_4.get(_8,"overflow-x")==="scroll"?_e.x=_d.x:_e.x=0;_4.get(_8,"overflow")==="scroll"?_e={x:_d.x,y:_d.y,permanent:true}:_e.permanent=false;}return _e;};if(_8){_9=_c(_7);return _9.permanent?_9:_a(_7,_9);}return {x:0,y:0};},getScrollbarSize:function(){function _f(){var _10;try{var _11=_3.create("div",{style:{overflow:"scroll",visibility:"hidden",position:"absolute",top:"-200px",left:"-200px",width:"100px",height:"100px"}},_2.body());_10={x:_11.offsetWidth-_11.clientWidth,y:_11.offsetHeight-_11.clientHeight};_3.destroy(_11);}catch(ex){_10={x:16,y:16};}return _10;};return _5._scrollbarSize=_5._scrollbarSize||_f();}});return _5;});