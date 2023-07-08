// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-no.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Norwegian localisation for calendars datepicker for jQuery.
   Written by Naimdjon Takhirov (naimdjon@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['no'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&laquo;Forrige',  prevStatus: '',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'Neste&raquo;', nextStatus: '',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'I dag', currentStatus: '',
		todayText: 'I dag', todayStatus: '',
		clearText: 'Tøm', clearStatus: '',
		closeText: 'Lukk', closeStatus: '',
		yearStatus: '', monthStatus: '',
		weekText: 'Uke', weekStatus: '',
		dayStatus: 'DD, M d', defaultStatus: '',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['no']);
})(jQuery);
