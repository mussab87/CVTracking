// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-ka.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Georgian localisation for calendars datepicker for jQuery.
   Andrei Gorbushkin. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['ka'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '<უკან', prevStatus: 'წინა თვე',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'წინა წელი',
		nextText: 'წინ>', nextStatus: 'შემდეგი თვე',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'შემდეგი წელი',
		currentText: 'მიმდინარე', currentStatus: 'მიმდინარე თვე',
		todayText: 'დღეს', todayStatus: 'მიმდინარე დღე',
		clearText: 'გასუფთავება', clearStatus: 'მიმდინარე თარიღის წაშლა',
		closeText: 'არის', closeStatus: 'დახურვა უცვლილებოდ',
		yearStatus: 'სხვა წელი', monthStatus: 'სხვა თვე',
		weekText: 'კვ', weekStatus: 'წლის კვირა',
		dayStatus: 'აირჩიეთ DD, M d', defaultStatus: 'აიღჩიეთ თარიღი',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['ka']);
})(jQuery);
