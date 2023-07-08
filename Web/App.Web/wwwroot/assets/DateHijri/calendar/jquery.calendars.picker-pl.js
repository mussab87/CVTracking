// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-pl.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Polish localisation for calendars datepicker for jQuery.
   Written by Jacek Wysocki (jacek.wysocki@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['pl'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;Poprzedni', prevStatus: 'Pokaż poprzedni miesiąc',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'Następny&#x3e;', nextStatus: 'Pokaż następny miesiąc',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'Dziś', currentStatus: 'Pokaż aktualny miesiąc',
		todayText: 'Dziś', todayStatus: 'Pokaż aktualny miesiąc',
		clearText: 'Wyczyść', clearStatus: 'Wyczyść obecną datę',
		closeText: 'Zamknij', closeStatus: 'Zamknij bez zapisywania',
		yearStatus: 'Pokaż inny rok', monthStatus: 'Pokaż inny miesiąc',
		weekText: 'Tydz', weekStatus: 'Tydzień roku',
		dayStatus: '\'Wybierz\' DD, M d', defaultStatus: 'Wybierz datę',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['pl']);
})(jQuery);
