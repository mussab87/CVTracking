﻿// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-tr.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Turkish localisation for calendars datepicker for jQuery.
   Written by Izzet Emre Erkan (kara@karalamalar.net). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['tr'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&#x3c;geri', prevStatus: 'önceki ayı göster',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: '',
		nextText: 'ileri&#x3e', nextStatus: 'sonraki ayı göster',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: '',
		currentText: 'bugün', currentStatus: '',
		todayText: 'bugün', todayStatus: '',
		clearText: 'temizle', clearStatus: 'geçerli tarihi temizler',
		closeText: 'kapat', closeStatus: 'sadece göstergeyi kapat',
		yearStatus: 'başka yıl', monthStatus: 'başka ay',
		weekText: 'Hf', weekStatus: 'Ayın haftaları',
		dayStatus: 'D, M d seçiniz', defaultStatus: 'Bir tarih seçiniz',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['tr']);
})(jQuery);
