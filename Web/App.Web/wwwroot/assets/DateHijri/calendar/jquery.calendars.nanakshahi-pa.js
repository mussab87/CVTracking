// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 01-23-2016
// ***********************************************************************
// <copyright file="jquery.calendars.nanakshahi-pa.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Punjabi localisation for Nanakshahi calendar for jQuery v2.0.2.
   Written by Sarbjit Singh January 2016. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendars.calendars.nanakshahi.prototype.regionalOptions['pa'] = {
		name: 'Nanakshahi',
		epochs: ['BN', 'AN'],
		monthNames: ['ਚੇਤ', 'ਵੈਸਾਖ', 'ਜੇਠ', 'ਹਾੜ', 'ਸਾਵਣ', 'ਭਾਦੋਂ', 'ਅੱਸੂ', 'ਕੱਤਕ', 'ਮੱਘਰ', 'ਪੋਹ', 'ਮਾਘ', 'ਫੱਗਣ'],
		monthNamesShort: ['ਚੇ', 'ਵੈ', 'ਜੇ', 'ਹਾ', 'ਸਾ', 'ਭਾ', 'ਅੱ', 'ਕੱ', 'ਮੱ', 'ਪੋ', 'ਮਾ', 'ਫੱ'],
		dayNames: ['ਐਤਵਾਰ', 'ਸੋਮਵਾਰ', 'ਮੰਗਲਵਾਰ', 'ਬੁੱਧਵਾਰ', 'ਵੀਰਵਾਰ', 'ਸ਼ੁੱਕਰਵਾਰ', 'ਸ਼ਨਿੱਚਰਵਾਰ'],
		dayNamesShort: ['ਐਤ', 'ਸੋਮ', 'ਮੰਗਲ', 'ਬੁੱਧ', 'ਵੀਰ', 'ਸ਼ੁੱਕਰ', 'ਸ਼ਨਿੱਚਰ'],
		dayNamesMin: ['ਐ', 'ਸੋ', 'ਮੰ', 'ਬੁੱ', 'ਵੀ', 'ਸ਼ੁੱ', 'ਸ਼'],
		digits: $.calendars.substituteDigits(['੦', '੧', '੨', '੩', '੪', '੫', '੬', '੭', '੮', '੯']),
		dateFormat: 'dd-mm-yyyy',
		firstDay: 0,
		isRTL: false
	};
})(jQuery);
