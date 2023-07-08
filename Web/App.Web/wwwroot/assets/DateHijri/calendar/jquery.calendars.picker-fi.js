// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-fi.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Finnish localisation for calendars datepicker for jQuery.
   Written by Harri Kilpiö (harrikilpio@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['fi'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&laquo;Edellinen', prevStatus: '',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'Seuraava&raquo;', nextStatus: '',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'T&auml;n&auml;&auml;n', currentStatus: '',
		todayText: 'T&auml;n&auml;&auml;n', todayStatus: '',
		clearText: 'Tyhjenn&auml;', clearStatus: '',
		closeText: 'Sulje', closeStatus: '',
		yearStatus: '', monthStatus: '',
		weekText: 'Vk', weekStatus: '',
		dayStatus: 'DD, M d', defaultStatus: '',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['fi']);
})(jQuery);
