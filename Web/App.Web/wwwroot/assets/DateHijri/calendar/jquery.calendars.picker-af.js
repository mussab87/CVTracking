﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-af.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Afrikaans localisation for calendars datepicker for jQuery.
   Written by Renier Pretorius and Ruediger Thiede. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['af'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: 'Vorige', prevStatus: 'Vertoon vorige maand',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'Vertoon vorige jaar',
		nextText: 'Volgende', nextStatus: 'Vertoon volgende maand',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'Vertoon volgende jaar',
		currentText: 'Vandag', currentStatus: 'Vertoon huidige maand',
		todayText: 'Vandag', todayStatus: 'Vertoon huidige maand',
		clearText: 'Vee uit', clearStatus: 'Verwyder die huidige datum',
		closeText: 'Klaar', closeStatus: 'Sluit sonder verandering',
		yearStatus: 'Vertoon \'n ander jaar', monthStatus: 'Vertoon \'n ander maand',
		weekText: 'Wk', weekStatus: 'Week van die jaar',
		dayStatus: 'Kies DD, M d', defaultStatus: 'Kies \'n datum',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['af']);
})(jQuery);
