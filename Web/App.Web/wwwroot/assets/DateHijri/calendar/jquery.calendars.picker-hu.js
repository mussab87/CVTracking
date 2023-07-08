// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-hu.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Hungarian localisation for calendars datepicker for jQuery.
   Written by Istvan Karaszi (jquerycalendar@spam.raszi.hu). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['hu'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&laquo;&nbsp;vissza', prevStatus: '',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'előre&nbsp;&raquo;', nextStatus: '',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'ma', currentStatus: '',
		todayText: 'ma', todayStatus: '',
		clearText: 'törlés', clearStatus: '',
		closeText: 'bezárás', closeStatus: '',
		yearStatus: '', monthStatus: '',
		weekText: 'Hé', weekStatus: '',
		dayStatus: 'DD, M d', defaultStatus: '',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['hu']);
})(jQuery);
