// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 10-14-2019
// ***********************************************************************
// <copyright file="jquery.calendars.picker-me-ME.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Montenegrin localisation for calendars datepicker for jQuery.
   Written by Miloš Milošević - fleka d.o.o. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['me-ME'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;', prevStatus: 'Prikaži prethodni mjesec',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'Prikaži prethodnu godinu',
		nextText: '&#x3e;', nextStatus: 'Prikaži sljedeći mjesec',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'Prikaži sljedeću godinu',
		currentText: 'Danas', currentStatus: 'Tekući mjesec',
		todayText: 'Danas', todayStatus: 'Tekući mjesec',
		clearText: 'Obriši', clearStatus: 'Obriši trenutni datum',
		closeText: 'Zatvori', closeStatus: 'Zatvori kalendar',
		yearStatus: 'Prikaži godine', monthStatus: 'Prikaži mjesece',
		weekText: 'Sed', weekStatus: 'Sedmica',
		dayStatus: '\'Datum\' DD, M d', defaultStatus: 'Odaberi datum',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['me-ME']);
})(jQuery);
