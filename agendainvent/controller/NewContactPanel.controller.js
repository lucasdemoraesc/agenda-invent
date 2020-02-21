sap.ui.define([
	"jquery.sap.global",
	"sap/m/MessageBox",
	"sap/m/MessageToast",
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel"
], function (jQuery, MessageBox, MessageToast, Controller, JSONModel) {
	"use strict";
	return Controller.extend("agendainvent.controller.NewContactPanel", {
		onInit: function () {
			this.oView = this.getView();

			this.oView.setModel(new JSONModel({
				recipient: {
					name: "",
					email: ""
				}
			}));

			// Anexar manipuladores para erros de validação
			sap.ui.getCore().getMessageManager().registerObject(this.oView.byId("inputName"), true);
			sap.ui.getCore().getMessageManager().registerObject(this.oView.byId("inputPhone"), true);
		},

		// Ao apertar o botão "Cadastrar"
		onCadBtnPress: function () {
			// collect input controls
			var that = this;
			var oView = this.getView();
			var aInputs = [
				oView.byId("inputName"),
				oView.byId("inputPhone")
			];
			var bValidationError = false;

			// check that inputs are not empty
			// this does not happen during data binding as this is only triggered by changes
			jQuery.each(aInputs, function (i, oInput) {
				bValidationError = that._validateInput(oInput) || bValidationError;
			});

			// output result
			if (!bValidationError) {
				MessageToast.show("Dados válidos.\nPronto para cadastro");
			} else {
				MessageBox.error("Os dados parecem incorretos. Verifique-os e tente novamente!");
			}
		},

		// Validar dados nas inputs
		_validateInput: function (oInput) {
			var oBinding = oInput.getBinding("value");
			var sValueState = "None";
			var bValidationError = false;

			try {
				oBinding.getType().validateValue(oInput.getValue());
			} catch (oException) {
				sValueState = "Error";
				bValidationError = true;
			}

			oInput.setValueState(sValueState);

			return bValidationError;
		},

		// Validar dados em tempo real
		handleValidationError: function (oEvent) {
			oEvent.getSource().setValueState(sap.ui.core.ValueState.Error);
		},

		// Validar dados em tempo real
		handleValidationSuccess: function (oEvent) {
			oEvent.getSource().setValueState(sap.ui.core.ValueState.Success);
		},

		// Ao alterar o valueState das inputs
		onIptChange: function (oEvent) {
			var oInput = oEvent.getSource();
			this._validateInput(oInput);
		}
	});
});