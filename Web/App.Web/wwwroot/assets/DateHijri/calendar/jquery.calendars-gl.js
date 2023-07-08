// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 01-14-2016
// ***********************************************************************
// <copyright file="jquery.calendars-gl.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Iniciacion en galego para a extensión 'UI date picker' para jQuery.
   Traducido por Manuel (McNuel@gmx.net). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendars.calendars.gregorian.prototype.regionalOptions['gl'] = {
		name: 'Gregorian',
		epochs: ['BCE', 'CE'],
		monthNames: ['Xaneiro','Febreiro','Marzo','Abril','Maio','Xuño',
		'Xullo','Agosto','Setembro','Outubro','Novembro','Decembro'],
		monthNamesShort: ['Xan','Feb','Mar','Abr','Mai','Xuñ',
		'Xul','Ago','Set','Out','Nov','Dec'],
		dayNames: ['Domingo','Luns','Martes','Mércores','Xoves','Venres','Sábado'],
		dayNamesShort: ['Dom','Lun','Mar','Mér','Xov','Ven','Sáb'],
		dayNamesMin: ['Do','Lu','Ma','Me','Xo','Ve','Sá'],
		digits: null,
		dateFormat: 'dd/mm/yyyy',
		firstDay: 1,
		isRTL: false
	};
	if ($.calendars.calendars.julian) {
		$.calendars.calendars.julian.prototype.regionalOptions['gl'] =
			$.calendars.calendars.gregorian.prototype.regionalOptions['gl'];
	}
})(jQuery);
