﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-ro.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Romanian localisation for calendars datepicker for jQuery.
   Written by Edmond L. (ll_edmond@walla.com) and Ionut G. Stan (ionut.g.stan@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['ro'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&laquo;Precedenta', prevStatus: 'Arata luna precedenta',
		prevJumpText: '&laquo;&laquo;', prevJumpStatus: '',
		nextText: 'Urmatoare&raquo;', nextStatus: 'Arata luna urmatoare',
		nextJumpText: '&raquo;&raquo;', nextJumpStatus: '',
		currentText: 'Azi', currentStatus: 'Arata luna curenta',
		todayText: 'Azi', todayStatus: 'Arata luna curenta',
		clearText: 'Curat', clearStatus: 'Sterge data curenta',
		closeText: 'Închide', closeStatus: 'Închide fara schimbare',
		yearStatus: 'Arat un an diferit', monthStatus: 'Arata o luna diferita',
		weekText: 'Săpt', weekStatus: 'Săptamana anului',
		dayStatus: 'Selecteaza DD, M d', defaultStatus: 'Selecteaza o data',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['ro']);
})(jQuery);
