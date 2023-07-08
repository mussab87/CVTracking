// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-lv.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Latvian localisation for calendars datepicker for jQuery.
   Arturas Paleicikas <arturas.paleicikas@metasite.net>. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['lv'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: 'Iepr',  prevStatus: '',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'Nāka', nextStatus: '',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'Šodien', currentStatus: '',
		todayText: 'Šodien', todayStatus: '',
		clearText: 'Notīrīt', clearStatus: '',
		closeText: 'Aizvērt', closeStatus: '',
		yearStatus: '', monthStatus: '',
		weekText: 'Nav', weekStatus: '',
		dayStatus: 'DD, M d', defaultStatus: '',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['lv']);
})(jQuery);
