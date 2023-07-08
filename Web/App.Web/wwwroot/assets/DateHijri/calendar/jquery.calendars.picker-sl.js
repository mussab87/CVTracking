// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-sl.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Slovenian localisation for calendars datepicker for jQuery.
   Written by Jaka Jancar (jaka@kubje.org). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['sl'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&lt;Prej&#x161;nji', prevStatus: 'Prika&#x17E;i prej&#x161;nji mesec',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'Naslednji&gt;', nextStatus: 'Prika&#x17E;i naslednji mesec',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'Trenutni', currentStatus: 'Prika&#x17E;i trenutni mesec',
		todayText: 'Trenutni', todayStatus: 'Prika&#x17E;i trenutni mesec',
		clearText: 'Izbri&#x161;i', clearStatus: 'Izbri&#x161;i trenutni datum',
		closeText: 'Zapri', closeStatus: 'Zapri brez spreminjanja',
		yearStatus: 'Prika&#x17E;i drugo leto', monthStatus: 'Prika&#x17E;i drug mesec',
		weekText: 'Teden', weekStatus: 'Teden v letu',
		dayStatus: 'Izberi DD, d MM yy', defaultStatus: 'Izbira datuma',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['sl']);
})(jQuery);
