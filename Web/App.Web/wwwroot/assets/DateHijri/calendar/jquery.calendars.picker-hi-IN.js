﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-hi-IN.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Hindi INDIA localisation for calendars datepicker for jQuery.
   Written by Pawan Kumar Singh. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['hi-IN'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: 'पिछला', prevStatus: 'पिछला महीना देखें',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'पिछला वर्ष देखें',
		nextText: 'अगला', nextStatus: 'अगला महीना देखें',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'अगला वर्ष देखें',
		currentText: 'वर्तमान', currentStatus: 'वर्तमान महीना देखें',
		todayText: 'आज', todayStatus: 'वर्तमान दिन देखें',
		clearText: 'साफ', clearStatus: 'वर्तमान दिनांक मिटाए',
		closeText: 'समाप्त', closeStatus: 'बदलाव के बिना बंद',
		yearStatus: 'एक अलग वर्ष का चयन करें', monthStatus: 'एक अलग महीने का चयन करें',
		weekText: 'Wk', weekStatus: 'वर्ष का सप्ताह',
		dayStatus: 'चुने DD, M d', defaultStatus: 'एक तिथि का चयन करें',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['hi-IN']);
})(jQuery);
