// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 10-14-2019
// ***********************************************************************
// <copyright file="jquery.calendars-me-ME.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Montenegrin localisation for Gregorian/Julian calendars for jQuery.
   By Miloš Milošević - fleka d.o.o. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendars.calendars.gregorian.prototype.regionalOptions['me-ME'] = {
		name: 'Gregorijanski',
		epochs: ['pne', 'ne'],
		monthNames: ['Januar','Februar','Mart','April','Maj','Jun',
		'Jul','Avgust','Septembar','Oktobar','Novembar','Decembar'],
		monthNamesShort: ['Jan', 'Feb', 'Mar', 'Apr', 'Maj', 'Jun',
		'Jul', 'Avg', 'Sep', 'Okt', 'Nov', 'Dec'],
		dayNames: ['Neđelja', 'Poneđeljak', 'Utorak', 'Srijeda', 'Četvrtak', 'Petak', 'Subota'],
		dayNamesShort: ['Neđ', 'Pon', 'Uto', 'Sri', 'Čet', 'Pet', 'Sub'],
		dayNamesMin: ['Ne','Po','Ut','Sr','Če','Pe','Su'],
		digits: null,
		dateFormat: 'dd/mm/yyyy',
		firstDay: 1,
		isRTL: false
	};
	if ($.calendars.calendars.julian) {
		$.calendars.calendars.julian.prototype.regionalOptions['me-ME'] =
			$.calendars.calendars.gregorian.prototype.regionalOptions['me-ME'];
	}
})(jQuery);
