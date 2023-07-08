// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 01-13-2016
// ***********************************************************************
// <copyright file="jquery.calendars.nepali-ne.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Nepali localisation for Nepali calendar for jQuery v2.0.2.
   Written by Artur Neumann (ict.projects{at}nepal.inf.org) April 2013. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendars.calendars.nepali.prototype.regionalOptions['ne'] = {
		name: 'Nepali',
		epochs: ['BBS', 'ABS'],
		monthNames: ['बैशाख', 'जेष्ठ', 'आषाढ', 'श्रावण', 'भाद्र', 'आश्विन', 'कार्तिक', 'मंसिर', 'पौष', 'माघ', 'फाल्गुन', 'चैत्र'],
		monthNamesShort: ['बै', 'जे', 'आषा', 'श्रा', 'भा', 'आश', 'का', 'मं', 'पौ', 'मा', 'फा', 'चै'],
		dayNames: ['आइतवार', 'सोमवार', 'मगलवार', 'बुधवार', 'बिहिवार', 'शुक्रवार', 'शनिवार'],
		dayNamesShort: ['आइत', 'सोम', 'मगल', 'बुध', 'बिहि', 'शुक्र', 'शनि'],
		dayNamesMin: ['आ', 'सो', 'म', 'बु', 'बि', 'शु', 'श'],
		digits: null,
		dateFormat: 'dd/mm/yyyy',
		firstDay: 1,
		isRTL: false
	};
})(jQuery);
