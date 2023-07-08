// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-am.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Amharic (አማርኛ) localisation for calendars datepicker for jQuery.
   Leyu Sisay. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['am'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: 'ያለፈ', prevStatus: 'ያለፈውን ወር አሳይ',
		prevJumpText: '&#x3c;&#x3c;', prevJumpStatus: 'ያለፈውን ዓመት አሳይ',
		nextText: 'ቀጣይ', nextStatus: 'ቀጣዩን ወር አሳይ',
		nextJumpText: '&#x3e;&#x3e;', nextJumpStatus: 'ቀጣዩን ዓመት አሳይ',
		currentText: 'አሁን', currentStatus: 'የአሁኑን ወር አሳይ',
		todayText: 'ዛሬ', todayStatus: 'የዛሬን ወር አሳይ',
		clearText: 'አጥፋ', clearStatus: 'የተመረጠውን ቀን አጥፋ',
		closeText: 'ዝጋ', closeStatus: 'የቀን መምረጫውን ዝጋ',
		yearStatus: 'ዓመቱን ቀይር', monthStatus: 'ወሩን ቀይር',
		weekText: 'ሳም', weekStatus: 'የዓመቱ ሳምንት ',
		dayStatus: 'DD, M d, yyyy ምረጥ', defaultStatus: 'ቀን ምረጥ',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['am']);
})(jQuery);
