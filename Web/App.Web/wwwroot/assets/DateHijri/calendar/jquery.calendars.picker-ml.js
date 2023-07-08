// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-ml.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Malayalam localisation for calendars datepicker for jQuery.
   Saji Nediyanchath (saji89@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['ml'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: 'മുന്നത്തെ', prevStatus: '',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'അടുത്തത് ', nextStatus: '',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'ഇന്ന്', currentStatus: '',
		todayText: 'ഇന്ന്', todayStatus: '',
		clearText: 'X', clearStatus: '',
		closeText: 'ശരി', closeStatus: '',
		yearStatus: '', monthStatus: '',
		weekText: 'ആ', weekStatus: '',
		dayStatus: 'DD d MM', defaultStatus: '',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['ml']);
})(jQuery);
