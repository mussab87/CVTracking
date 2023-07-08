// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 01-14-2016
// ***********************************************************************
// <copyright file="jquery.calendars-ur.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Urdu localisation for Gregorian/Julian calendars for jQuery.
   Mansoor Munib -- mansoormunib@gmail.com <http://www.mansoor.co.nr/mansoor.html>
   Thanks to Habib Ahmed, ObaidUllah Anwar. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendars.calendars.gregorian.prototype.regionalOptions['ur'] = {
		name: 'Gregorian',
		epochs: ['BCE', 'CE'],
		monthNames: ['جنوری','فروری','مارچ','اپریل','مئی','جون',
		'جولائی','اگست','ستمبر','اکتوبر','نومبر','دسمبر'],
		monthNamesShort: ['1','2','3','4','5','6',
		'7','8','9','10','11','12'],
		dayNames: ['اتوار','پير','منگل','بدھ','جمعرات','جمعہ','ہفتہ'],
		dayNamesShort: ['اتوار','پير','منگل','بدھ','جمعرات','جمعہ','ہفتہ'],
		dayNamesMin: ['اتوار','پير','منگل','بدھ','جمعرات','جمعہ','ہفتہ'],
		digits: $.calendars.substituteDigits(['٠', '١', '٢', '٣', '۴', '۵', '۶', '۷', '٨', '٩']),
		dateFormat: 'dd/mm/yyyy',
		firstDay: 0,
		firstDay: 1,
		isRTL: true
	};
	if ($.calendars.calendars.julian) {
		$.calendars.calendars.julian.prototype.regionalOptions['ur'] =
			$.calendars.calendars.gregorian.prototype.regionalOptions['ur'];
	}
})(jQuery);
