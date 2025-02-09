﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-id.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Indonesian localisation for calendars datepicker for jQuery.
   Written by Deden Fathurahman (dedenf@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['id'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;mundur', prevStatus: 'Tampilkan bulan sebelumnya',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'maju&#x3e;', nextStatus: 'Tampilkan bulan berikutnya',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'hari ini', currentStatus: 'Tampilkan bulan sekarang',
		todayText: 'hari ini', todayStatus: 'Tampilkan bulan sekarang',
		clearText: 'kosongkan', clearStatus: 'bersihkan tanggal yang sekarang',
		closeText: 'Tutup', closeStatus: 'Tutup tanpa mengubah',
		yearStatus: 'Tampilkan tahun yang berbeda', monthStatus: 'Tampilkan bulan yang berbeda',
		weekText: 'Mg', weekStatus: 'Minggu dalam tahu',
		dayStatus: 'pilih le DD, MM d', defaultStatus: 'Pilih Tanggal',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['id']);
})(jQuery);
