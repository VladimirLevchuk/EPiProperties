//>>built
define("epi/cms/widget/NotificationStatusZone",["dojo","dojo/_base/declare","dijit/_Widget","dijit/_TemplatedMixin"],function(_1,_2,_3,_4){return _2("epi.cms.widget.NotificationStatusZone",[_3,_4],{templateString:"            <div>                <div class=\"epi-dijitTooltipNotificationBlock epi-dijitTooltipBlock${TypeName}\" data-dojo-attach-point=\"Zone\">                    <span class=\"epi-notificationTypeTitle\"><span class=\"dijitIcon dijitInline epi-dijitTooltip${TypeName}Icon\"></span>${title}</span>                    <ul data-dojo-attach-point=\"contentContainer\"></ul>                </div>            </div>",title:"",type:"",TypeName:"",_hiddenCssClass:"epi-dijitTooltipBlockHidden",postMixInProperties:function(){this.TypeName=this.type.charAt(0).toUpperCase()+this.type.slice(1);},empty:function(){_1.empty(this.contentContainer);},addRow:function(_5,_6){_1.place(_5,this.contentContainer,_6);},show:function(){_1.removeClass(this.Zone,this._hiddenCssClass);},hide:function(){_1.addClass(this.Zone,this._hiddenCssClass);}});});