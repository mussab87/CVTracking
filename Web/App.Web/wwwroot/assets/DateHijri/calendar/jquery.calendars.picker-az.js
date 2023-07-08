// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-az.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Azerbaijani localisation for calendars datepicker for jQuery.
   Written by Jamil Najafov (necefov33@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['az'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;Geri',  prevStatus: 'Əvvəlki ay',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'Əvvəlki il',
		nextText: 'İrəli&#x3e;', nextStatus: 'Sonrakı ay',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'Sonrakı il',
		currentText: 'Bugün', currentStatus: 'İndiki ay',
		todayText: 'Bugün', todayStatus: 'İndiki ay',
		clearText: 'Təmizlə', clearStatus: 'Tarixi sil',
		closeText: 'Bağla', closeStatus: 'Təqvimi bağla',
		yearStatus: 'Başqa il', monthStatus: 'Başqa ay',
		weekText: 'Hf', weekStatus: 'Həftələr',
		dayStatus: 'D, M d seçin', defaultStatus: 'Bir tarix seçin',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['az']);
})(jQuery);
