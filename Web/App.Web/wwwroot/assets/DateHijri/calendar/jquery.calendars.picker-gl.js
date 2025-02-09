﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 11-09-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-gl.js" company="Expert Systems">
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
	$.calendarsPicker.regionalOptions['gl'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;Ant', prevStatus: 'Amosar mes anterior',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'Amosar ano anterior',
		nextText: 'Seg&#x3e;', nextStatus: 'Amosar mes seguinte',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'Amosar ano seguinte',
		currentText: 'Hoxe', currentStatus: 'Amosar mes actual',
		todayText: 'Hoxe', todayStatus: 'Amosar mes actual',
		clearText: 'Limpar', clearStatus: 'Borrar data actual',
		closeText: 'Pechar', closeStatus: 'Pechar sen gardar',
		yearStatus: 'Amosar outro ano', monthStatus: 'Amosar outro mes',
		weekText: 'Sm', weekStatus: 'Semana do ano',
		dayStatus: 'D, M d', defaultStatus: 'Selecciona Data',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['gl']);
})(jQuery);
