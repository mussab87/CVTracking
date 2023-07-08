// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-lt.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Lithuanian localisation for calendars datepicker for jQuery.
   Arturas Paleicikas <arturas@avalon.lt>. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['lt'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;Atgal',  prevStatus: '',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'Pirmyn&#x3e;', nextStatus: '',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'Šiandien', currentStatus: '',
		todayText: 'Šiandien', todayStatus: '',
		clearText: 'Išvalyti', clearStatus: '',
		closeText: 'Uždaryti', closeStatus: '',
		yearStatus: '', monthStatus: '',
		weekText: 'Wk', weekStatus: '',
		dayStatus: 'DD, M d', defaultStatus: '',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['lt']);
})(jQuery);
