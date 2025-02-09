﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-sr.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Serbian localisation for calendars datepicker for jQuery.
   Written by Dejan Dimić. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['sr'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;', prevStatus: 'Прикажи предходни месец',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'Прикажи предходну годину',
		nextText: '&#x3e;', nextStatus: 'Прикажи слецећи месец',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'Прикажи следећу годину',
		currentText: 'Данас', currentStatus: 'Текући месец',
		todayText: 'Данас', todayStatus: 'Текући месец',
		clearText: 'Обриши', clearStatus: 'Обриши тренутни датум',
		closeText: 'Затвори', closeStatus: 'Затвори календар',
		yearStatus: 'Прикажи године', monthStatus: 'Прикажи месеце',
		weekText: 'Сед', weekStatus: 'Седмица',
		dayStatus: '\'Датум\' DD d MM', defaultStatus: 'Одабери датум',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['sr']);
})(jQuery);
