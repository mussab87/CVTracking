// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 01-23-2016
// ***********************************************************************
// <copyright file="jquery.calendars.ethiopian-am.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Amharic localisation for Ethiopian calendar for jQuery v2.0.2.
   Written by Tewodros Zena February 2010. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendars.calendars.ethiopian.prototype.regionalOptions['am'] = {
		name: 'የኢትዮጵያ ዘመን አቆጣጠር',
		epochs: ['BEE', 'EE'],
		monthNames: ['መስከረም', 'ጥቅምት', 'ኅዳር', 'ታህሣሥ', 'ጥር', 'የካቲት',
		'መጋቢት', 'ሚያዝያ', 'ግንቦት', 'ሰኔ', 'ሐምሌ', 'ነሐሴ', 'ጳጉሜ'],
		monthNamesShort: ['መስከ', 'ጥቅም', 'ኅዳር', 'ታህሣ', 'ጥር', 'የካቲ',
		'መጋቢ', 'ሚያዝ', 'ግንቦ', 'ሰኔ', 'ሐምሌ', 'ነሐሴ', 'ጳጉሜ'],
		dayNames: ['እሑድ', 'ሰኞ', 'ማክሰኞ', 'ረቡዕ', 'ሓሙስ', 'ዓርብ', 'ቅዳሜ'],
		dayNamesShort: ['እሑድ', 'ሰኞ', 'ማክሰ', 'ረቡዕ', 'ሓሙስ', 'ዓርብ', 'ቅዳሜ'],
		dayNamesMin: ['እሑ', 'ሰኞ', 'ማክ', 'ረቡ', 'ሐሙ', 'ዓር', 'ቅዳ'],
		digits: null,
		dateFormat: 'dd/mm/yyyy',
		firstDay: 0,
		isRTL: false
	};
})(jQuery);
