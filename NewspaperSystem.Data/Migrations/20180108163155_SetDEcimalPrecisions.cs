using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NewspaperSystem.Data.Migrations
{
    public partial class SetDEcimalPrecisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "Wischwassers",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "Tapes",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PlateExposing",
                table: "ServicePrices",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Packing",
                table: "ServicePrices",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "MachineSetup",
                table: "ServicePrices",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Impression",
                table: "ServicePrices",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "Plates",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "PlateDevelopers",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Value5",
                table: "PaperWastes",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Value4",
                table: "PaperWastes",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Value3",
                table: "PaperWastes",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Value2",
                table: "PaperWastes",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Value1",
                table: "PaperWastes",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PrintingWaste",
                table: "PaperWastes",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "CoreWaste",
                table: "PaperWastes",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "Papers",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Orders",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "WischwasserPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "WischwasserKg",
                table: "OrderCalcs",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TapePrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TapeMeters",
                table: "OrderCalcs",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PrintingPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PlatesPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PlateExposingPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PaperWastePrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PaperWasteKg",
                table: "OrderCalcs",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PaperPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PaperKg",
                table: "OrderCalcs",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PackingPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "MachineSetupPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "FoilPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "FoilKg",
                table: "OrderCalcs",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "ColorInksPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "ColorInksKg",
                table: "OrderCalcs",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "BlindsPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "BlackInkPrice",
                table: "OrderCalcs",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "BlackInkKg",
                table: "OrderCalcs",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Wischwasser",
                table: "MaterialConsumptions",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Tape",
                table: "MaterialConsumptions",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PlateDeveloper",
                table: "MaterialConsumptions",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PageWidth",
                table: "MaterialConsumptions",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PageHeight",
                table: "MaterialConsumptions",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "InkColor",
                table: "MaterialConsumptions",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "InkBlack",
                table: "MaterialConsumptions",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Foil",
                table: "MaterialConsumptions",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "Foils",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "ColorInks",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "VatNumber",
                table: "Clients",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                table: "Clients",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Clients",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "BlindPlates",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "BlackInks",
                type: "decimal(8, 4)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "Wischwassers",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "Tapes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PlateExposing",
                table: "ServicePrices",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Packing",
                table: "ServicePrices",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "MachineSetup",
                table: "ServicePrices",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Impression",
                table: "ServicePrices",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "Plates",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "PlateDevelopers",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value5",
                table: "PaperWastes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value4",
                table: "PaperWastes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value3",
                table: "PaperWastes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value2",
                table: "PaperWastes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value1",
                table: "PaperWastes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrintingWaste",
                table: "PaperWastes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CoreWaste",
                table: "PaperWastes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "Papers",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "WischwasserPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "WischwasserKg",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TapePrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "TapeMeters",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrintingPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "PlatesPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "PlateExposingPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaperWastePrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaperWasteKg",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaperPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaperKg",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PackingPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "MachineSetupPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "FoilPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "FoilKg",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ColorInksPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "ColorInksKg",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BlindsPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "BlackInkPrice",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "BlackInkKg",
                table: "OrderCalcs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Wischwasser",
                table: "MaterialConsumptions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tape",
                table: "MaterialConsumptions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PlateDeveloper",
                table: "MaterialConsumptions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PageWidth",
                table: "MaterialConsumptions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PageHeight",
                table: "MaterialConsumptions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "InkColor",
                table: "MaterialConsumptions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "InkBlack",
                table: "MaterialConsumptions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Foil",
                table: "MaterialConsumptions",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "Foils",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "ColorInks",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<string>(
                name: "VatNumber",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "BlindPlates",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SafetyMargin",
                table: "BlackInks",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 4)");
        }
    }
}
