/*
@license

dhtmlxGantt v.6.2.0 Professional Evaluation
This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.

*/
Gantt.plugin(function(e){!function(e,t){if("object"==typeof exports&&"object"==typeof module)module.exports=t();else if("function"==typeof define&&define.amd)define([],t);else{var n=t();for(var r in n)("object"==typeof exports?exports:e)[r]=n[r]}}(window,function(){return function(e){var t={};function n(r){if(t[r])return t[r].exports;var o=t[r]={i:r,l:!1,exports:{}};return e[r].call(o.exports,o,o.exports,n),o.l=!0,o.exports}return n.m=e,n.c=t,n.d=function(e,t,r){n.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:r})},n.r=function(e){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},n.t=function(e,t){if(1&t&&(e=n(e)),8&t)return e;if(4&t&&"object"==typeof e&&e&&e.__esModule)return e;var r=Object.create(null);if(n.r(r),Object.defineProperty(r,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var o in e)n.d(r,o,function(t){return e[t]}.bind(null,o));return r},n.n=function(e){var t=e&&e.__esModule?function(){return e.default}:function(){return e};return n.d(t,"a",t),t},n.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},n.p="/codebase/",n(n.s=213)}({213:function(t,n){e.locale={date:{month_full:["Januar","Februar","Marts","April","Maj","Juni","Juli","August","September","Oktober","November","December"],month_short:["Jan","Feb","Mar","Apr","Maj","Jun","Jul","Aug","Sep","Okt","Nov","Dec"],day_full:["Søndag","Mandag","Tirsdag","Onsdag","Torsdag","Fredag","Lørdag"],day_short:["Søn","Man","Tir","Ons","Tor","Fre","Lør"]},labels:{new_task:"Ny opgave",dhx_cal_today_button:"Idag",day_tab:"Dag",week_tab:"Uge",month_tab:"Måned",new_event:"Ny begivenhed",icon_save:"Gem",icon_cancel:"Fortryd",icon_details:"Detaljer",icon_edit:"Tilret",icon_delete:"Slet",confirm_closing:"Dine rettelser vil gå tabt.. Er dy sikker?",confirm_deleting:"Bigivenheden vil blive slettet permanent. Er du sikker?",section_description:"Beskrivelse",section_time:"Tidsperiode",section_type:"Type",column_wbs:"WBS",column_text:"Task name",column_start_date:"Start time",column_duration:"Duration",column_add:"",link:"Link",confirm_link_deleting:"will be deleted",link_start:" (start)",link_end:" (end)",type_task:"Task",type_project:"Project",type_milestone:"Milestone",minutes:"Minutes",hours:"Hours",days:"Days",weeks:"Week",months:"Months",years:"Years",message_ok:"OK",message_cancel:"Fortryd",section_constraint:"Constraint",constraint_type:"Constraint type",constraint_date:"Constraint date",asap:"As Soon As Possible",alap:"As Late As Possible",snet:"Start No Earlier Than",snlt:"Start No Later Than",fnet:"Finish No Earlier Than",fnlt:"Finish No Later Than",mso:"Must Start On",mfo:"Must Finish On",resources_filter_placeholder:"type to filter",resources_filter_label:"hide empty"}}}})})});