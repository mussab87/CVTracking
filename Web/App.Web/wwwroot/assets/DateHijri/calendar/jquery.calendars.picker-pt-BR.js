// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 08-23-2015
// ***********************************************************************
// <copyright file="jquery.calendars.picker-pt-BR.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/* http://keith-wood.name/calendars.html
   Brazilian Portuguese localisation for calendars datepicker for jQuery.
   Written by Leonildo Costa Silva (leocsilva@gmail.com). */
(function($) {
	/// <summary>
	/// </summary>
	/// <param name="$">The $.</param>
	$.calendarsPicker.regionalOptions['pt-BR'] = {
		renderer: $.calendarsPicker.defaultRenderer,
		prevText: '&lt;Anterior', prevStatus: 'Mostra o mês anterior', 
		prevJumpText: '&lt;&lt;', prevJumpStatus: 'Mostra o ano anterior', 
		nextText: 'Próximo&gt;', nextStatus: 'Mostra o próximo mês', 
		nextJumpText: '&gt;&gt;', nextJumpStatus: 'Mostra o próximo ano',
		currentText: 'Atual', currentStatus: 'Mostra o mês atual',
		todayText: 'Hoje', todayStatus: 'Vai para hoje', 
		clearText: 'Limpar', clearStatus: 'Limpar data',
		closeText: 'Fechar', closeStatus: 'Fechar o calendário',
		yearStatus: 'Selecionar ano', monthStatus: 'Selecionar mês',
		weekText: 's', weekStatus: 'Semana do ano', 
		dayStatus: 'DD, d \'de\' M \'de\' yyyy', defaultStatus: 'Selecione um dia',
		isRTL: false
	};
	$.calendarsPicker.setDefaults($.calendarsPicker.regionalOptions['pt-BR']);
})(jQuery);
