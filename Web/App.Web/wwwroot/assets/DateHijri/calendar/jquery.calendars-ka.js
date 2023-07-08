// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 01-14-2016
// ***********************************************************************
// <copyright file="jquery.calendars-ka.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Georgian localisation for Gregorian/Julian calendars for jQuery.
   Andrei Gorbushkin. */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendars.calendars.gregorian.prototype.regionalOptions['ka'] = {
		name: 'Gregorian',
		epochs: ['BCE', 'CE'],
		monthNames: ['იანვარი','თებერვალი','მარტი','აპრილი','მაისი','ივნისი',
		'ივლისი','აგვისტო','სექტემბერი','ოქტომბერი','ნოემბერი','დეკემბერი'],
		monthNamesShort: ['იან', 'თებ', 'მარ', 'აპრ', 'მაისი', 'ივნ',
		'ივლ', 'აგვ', 'სექ', 'ოქტ', 'ნოე', 'დეკ'],
		dayNames: ['კვირა', 'ორშაბათი', 'სამშაბათი', 'ოთხშაბათი', 'ხუთშაბათი', 'პარასკევი', 'შაბათი'],
		dayNamesShort: ['კვ', 'ორშ', 'სამ', 'ოთხ', 'ხუთ', 'პარ', 'შაბ'],
		dayNamesMin: ['კვ','ორ','სმ','ოთ', 'ხშ', 'პრ','შბ'],
		digits: null,
		dateFormat: 'dd/mm/yyyy',
		firstDay: 1,
		isRTL: false
	};
	if ($.calendars.calendars.julian) {
		$.calendars.calendars.julian.prototype.regionalOptions['ka'] =
			$.calendars.calendars.gregorian.prototype.regionalOptions['ka'];
	}
})(jQuery);
