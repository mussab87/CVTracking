﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-fo.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Faroese localisation for calendars datepicker for jQuery.
   Written by Sverri Mohr Olsen, sverrimo@gmail.com */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['fo'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;Sísta', prevStatus: 'Vís sísta mánaðan',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'Vís sísta árið',
		nextText: 'Næsta&#x3e;', nextStatus: 'Vís næsta mánaðan',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'Vís næsta árið',
		currentText: 'Hesin', currentStatus: 'Vís hendan mánaðan',
		todayText: 'Í dag', todayStatus: 'Vís mánaðan fyri í dag',
		clearText: 'Strika', clearStatus: 'Strika allir mánaðarnar',
		closeText: 'Goym', closeStatus: 'Goym hetta vindeyðga',
		yearStatus: 'Broyt árið', monthStatus: 'Broyt mánaðans',
		weekText: 'Vk', weekStatus: 'Vika av árinum',
		dayStatus: 'Vel DD, M d, yyyy', defaultStatus: 'Vel ein dato',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['fo']);
})(jQuery);
