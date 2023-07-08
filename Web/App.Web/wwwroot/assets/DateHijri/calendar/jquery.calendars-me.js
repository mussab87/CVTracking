// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 10-14-2019
// ***********************************************************************
// <copyright file="jquery.calendars-me.js" company="Expert Systems">
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
	$.calendars.calendars.gregorian.prototype.regionalOptions['me'] = {
		name: 'Грегоријански',
		epochs: ['пне', 'не'],
		monthNames: ['Јануар','Фебруар','Март','Април','Мај','Јун',
		'Јул','Август','Септембар','Октобар','Новембар','Децембар'],
		monthNamesShort: ['Јан', 'Феб', 'Мар', 'Апр', 'Мај', 'Јун',
		'Јул', 'Авг', 'Сеп', 'Окт', 'Нов', 'Дец'],
		dayNames: ['Неђеља', 'Понеђељак', 'Уторак', 'Сриједа', 'Четвртак', 'Петак', 'Субота'],
		dayNamesShort: ['Неђ', 'Пон', 'Уто', 'Сри', 'Чет', 'Пет', 'Суб'],
		dayNamesMin: ['Не','По','Ут','Ср','Че','Пе','Су'],
		digits: null,
		dateFormat: 'dd/mm/yyyy',
		firstDay: 1,
		isRTL: false
	};
	if ($.calendars.calendars.julian) {
		$.calendars.calendars.julian.prototype.regionalOptions['me'] =
			$.calendars.calendars.gregorian.prototype.regionalOptions['me'];
	}
})(jQuery);
