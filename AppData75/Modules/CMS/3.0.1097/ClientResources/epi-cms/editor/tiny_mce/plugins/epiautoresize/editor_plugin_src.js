(function(tinymce,$){tinymce.create("tinymce.plugins.epiautoresizeplugin",{init:function(ed){function resize(){var height=this.getBody().parentNode.scrollHeight;height>0&&(this.getContentAreaContainer().firstChild.style.height=height+"px",$(this.getContainer()).resize())}ed.getParam("fullscreen_is_enabled")||(ed.onInit.add(function(ed){(tinymce.isIE?ed.getBody().parentNode:ed.getBody()).style.overflowY="hidden",ed.getContainer().lastChild.style.height="auto",tinymce.DOM.setStyles(ed.getBody(),{margin:"0",padding:"0",height:"auto"}),ed.onChange.add(resize),ed.onSetContent.add(resize),ed.onPaste.add(resize),ed.onKeyUp.add(resize),ed.onPostRender.add(resize),ed.onMouseUp.add(resize)}),ed.addCommand("mceepiAutoResize",resize))},getInfo:function(){return{longname:"Auto resize plugin",author:"EPiServer AB",authorurl:"http://www.episerver.com",infourl:"http://www.episerver.com",version:1}}}),tinymce.PluginManager.add("epiautoresize",tinymce.plugins.epiautoresizeplugin)})(tinymce,epiJQuery);