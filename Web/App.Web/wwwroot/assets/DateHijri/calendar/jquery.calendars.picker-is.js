// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-is.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Icelandic localisation for calendars datepicker for jQuery.
   Written by Haukur H. Thorsson (haukur@eskill.is). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['is'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c; Fyrri', prevStatus: '',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'N&aelig;sti &#x3e;', nextStatus: '',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: '&Iacute; dag', currentStatus: '',
		todayText: '&Iacute; dag', todayStatus: '',
		clearText: 'Hreinsa', clearStatus: '',
		closeText: 'Loka', closeStatus: '',
		yearStatus: '', monthStatus: '',
		weekText: 'Vika', weekStatus: '',
		dayStatus: 'DD, M d', defaultStatus: '',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['is']);
})(jQuery);
