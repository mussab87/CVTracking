﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-cs.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Czech localisation for calendars datepicker for jQuery.
   Written by Tomas Muller (tomas@tomas-muller.net). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['cs'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;Dříve', prevStatus: 'Přejít na předchozí měsí',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'Později&#x3e;', nextStatus: 'Přejít na další měsíc',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'Nyní', currentStatus: 'Přejde na aktuální měsíc',
		todayText: 'Nyní', todayStatus: 'Přejde na aktuální měsíc',
		clearText: 'Vymazat', clearStatus: 'Vymaže zadané datum',
		closeText: 'Zavřít',  closeStatus: 'Zavře kalendář beze změny',
		yearStatus: 'Přejít na jiný rok', monthStatus: 'Přejít na jiný měsíc',
		weekText: 'Týd', weekStatus: 'Týden v roce',
		dayStatus: '\'Vyber\' DD, M d', defaultStatus: 'Vyberte datum',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['cs']);
})(jQuery);
