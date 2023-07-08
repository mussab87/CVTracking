// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-hr.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Croatian localisation for calendars datepicker for jQuery.
   Written by Vjekoslav Nesek. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['hr'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;', prevStatus: 'Prikaži prethodni mjesec',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: '&#x3e;', nextStatus: 'Prikaži slijedeći mjesec',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'Danas', currentStatus: 'Današnji datum',
		todayText: 'Danas', todayStatus: 'Današnji datum',
		clearText: 'izbriši', clearStatus: 'Izbriši trenutni datum',
		closeText: 'Zatvori', closeStatus: 'Zatvori kalendar',
		yearStatus: 'Prikaži godine', monthStatus: 'Prikaži mjesece',
		weekText: 'Tje', weekStatus: 'Tjedanr',
		dayStatus: '\'Datum\' DD, M d', defaultStatus: 'Odaberi datum',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['hr']);
})(jQuery);
