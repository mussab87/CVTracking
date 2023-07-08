// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-de.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   German localisation for calendars datepicker for jQuery.
   Written by Milian Wolff (mail@milianw.de). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['de'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;zurück', prevStatus: 'letzten Monat zeigen',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'Vor&#x3e;', nextStatus: 'nächsten Monat zeigen',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'heute', currentStatus: '',
		todayText: 'heute', todayStatus: '',
		clearText: 'löschen', clearStatus: 'aktuelles Datum löschen',
		closeText: 'schließen', closeStatus: 'ohne Änderungen schließen',
		yearStatus: 'anderes Jahr anzeigen', monthStatus: 'anderen Monat anzeige',
		weekText: 'Wo', weekStatus: 'Woche des Monats',
		dayStatus: 'Wähle D, M d', defaultStatus: 'Wähle ein Datum',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['de']);
})(jQuery);
