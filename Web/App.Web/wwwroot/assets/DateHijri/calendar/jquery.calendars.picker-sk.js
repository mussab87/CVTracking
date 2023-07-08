// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-sk.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Slovak localisation for calendars datepicker for jQuery.
   Written by Vojtech Rinik (vojto@hmm.sk). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['sk'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;Predchádzajúci',  prevStatus: '',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'Nasledujúci&#x3e;', nextStatus: '',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'Dnes', currentStatus: '',
		todayText: 'Dnes', todayStatus: '',
		clearText: 'Zmazať', clearStatus: '',
		closeText: 'Zavrieť', closeStatus: '',
		yearStatus: '', monthStatus: '',
		weekText: 'Ty', weekStatus: '',
		dayStatus: 'DD. M d', defaultStatus: '',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['sk']);
})(jQuery);
