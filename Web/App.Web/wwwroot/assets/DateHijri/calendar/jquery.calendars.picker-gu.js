// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-gu.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Gujarati (ગુજરાતી) localisation for calendars datepicker for jQuery.
   Naymesh Mistry (naymesh@yahoo.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['gu'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;પાછળ', prevStatus: 'પાછલો મહિનો બતાવો',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'પાછળ',
		nextText: 'આગળ&#x3e;', nextStatus: 'આગલો મહિનો બતાવો',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'આગળ',
		currentText: 'આજે', currentStatus: 'આજનો દિવસ બતાવો',
		todayText: 'આજે', todayStatus: 'આજનો દિવસ',
		clearText: 'ભૂંસો', clearStatus: 'હાલ પસંદ કરેલી તારીખ ભૂંસો',
		closeText: 'બંધ કરો', closeStatus: 'તારીખ પસંદ કર્યા વગર બંધ કરો',
		yearStatus: 'જુદુ વર્ષ બતાવો', monthStatus: 'જુદો મહિનો બતાવો',
		weekText: 'અઠવાડિયું', weekStatus: 'અઠવાડિયું',
		dayStatus: 'અઠવાડિયાનો પહેલો દિવસ પસંદ કરો', defaultStatus: 'તારીખ પસંદ કરો',		
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['gu']);
})(jQuery);
