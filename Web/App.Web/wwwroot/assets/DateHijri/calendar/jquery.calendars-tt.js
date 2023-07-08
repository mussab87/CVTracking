// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 01-14-2016
// ***********************************************************************
// <copyright file="jquery.calendars-tt.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Tatar localisation for Gregorian/Julian calendars for jQuery.
   Written by Ирек Хаҗиев (khazirek@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendars.calendars.gregorian.prototype.regionalOptions['tt'] = {
		name: 'Gregorian',
		epochs: ['BCE', 'CE'],
		monthNames: ['Гынвар','Февраль','Март','Апрель','Май','Июнь',
		'Июль','Август','Сентябрь','Октябрь','Ноябрь','Декабрь'],
		monthNamesShort: ['Гыйн','Фев','Мар','Апр','Май','Июн',
		'Июл','Авг','Сен','Окт','Ноя','Дек'],
		dayNames: ['якшәмбе','дүшәмбе','сишәмбе','чәршәмбе','пәнҗешәмбе','җомга','шимбә'],
		dayNamesShort: ['якш','дүш','сиш','чәр','пән','җом','шим'],
		dayNamesMin: ['Як','Дү','Си','Чә','Пә','Җо','Ши'],
		digits: null,
		dateFormat: 'dd.mm.yyyy',
		firstDay: 1,
		isRTL: false
	};
	if ($.calendars.calendars.julian) {
		$.calendars.calendars.julian.prototype.regionalOptions['tt'] =
			$.calendars.calendars.gregorian.prototype.regionalOptions['tt'];
	}
})(jQuery);
