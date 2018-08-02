/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

DELETE FROM `region`;
/*!40000 ALTER TABLE `region` DISABLE KEYS */;
INSERT INTO `region` (`Id`, `RegionName`, `ParentId`, `Sort`, `IsShow`, `IsDeleted`, `DeleterUserId`, `DeletionTime`, `LastModificationTime`, `LastModifierUserId`, `CreationTime`, `CreatorUserId`) VALUES
	(110000, '北京市', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(110100, '市辖区', 110000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(110200, '县', 110000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(120000, '天津市', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(120100, '市辖区', 120000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(120200, '县', 120000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(130000, '河北省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(130100, '石家庄市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(130200, '唐山市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(130300, '秦皇岛市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(130400, '邯郸市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(130500, '邢台市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(130600, '保定市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(130700, '张家口市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(130800, '承德市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(130900, '沧州市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(131000, '廊坊市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(131100, '衡水市', 130000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(140000, '山西省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(140100, '太原市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(140200, '大同市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(140300, '阳泉市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(140400, '长治市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(140500, '晋城市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(140600, '朔州市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(140700, '晋中市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(140800, '运城市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(140900, '忻州市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(141000, '临汾市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(141100, '吕梁市', 140000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(150000, '内蒙古自治区', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(150100, '呼和浩特市', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(150200, '包头市', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(150300, '乌海市', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(150400, '赤峰市', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(150500, '通辽市', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(150600, '鄂尔多斯市', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(150700, '呼伦贝尔市', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(150800, '巴彦淖尔市', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(150900, '乌兰察布市', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(152200, '兴安盟', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(152500, '锡林郭勒盟', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(152900, '阿拉善盟', 150000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(210000, '辽宁省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(210100, '沈阳市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(210200, '大连市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(210300, '鞍山市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(210400, '抚顺市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(210500, '本溪市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(210600, '丹东市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(210700, '锦州市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(210800, '营口市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(210900, '阜新市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(211000, '辽阳市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(211100, '盘锦市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(211200, '铁岭市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(211300, '朝阳市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(211400, '葫芦岛市', 210000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(220000, '吉林省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(220100, '长春市', 220000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(220200, '吉林市', 220000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(220300, '四平市', 220000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(220400, '辽源市', 220000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(220500, '通化市', 220000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(220600, '白山市', 220000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(220700, '松原市', 220000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(220800, '白城市', 220000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(222400, '延边朝鲜族自治州', 220000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(230000, '黑龙江省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(230100, '哈尔滨市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(230200, '齐齐哈尔市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(230300, '鸡西市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(230400, '鹤岗市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(230500, '双鸭山市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(230600, '大庆市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(230700, '伊春市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(230800, '佳木斯市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(230900, '七台河市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(231000, '牡丹江市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(231100, '黑河市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(231200, '绥化市', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(232700, '大兴安岭地区', 230000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(310000, '上海市', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(310100, '市辖区', 310000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(310200, '县', 310000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(320000, '江苏省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(320100, '南京市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(320200, '无锡市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(320300, '徐州市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(320400, '常州市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(320500, '苏州市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(320600, '南通市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(320700, '连云港市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(320800, '淮安市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(320900, '盐城市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(321000, '扬州市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(321100, '镇江市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(321200, '泰州市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(321300, '宿迁市', 320000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(330000, '浙江省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(330100, '杭州市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(330200, '宁波市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(330300, '温州市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(330400, '嘉兴市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(330500, '湖州市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(330600, '绍兴市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(330700, '金华市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(330800, '衢州市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(330900, '舟山市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(331000, '台州市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(331100, '丽水市', 330000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(340000, '安徽省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(340100, '合肥市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(340200, '芜湖市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(340300, '蚌埠市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(340400, '淮南市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(340500, '马鞍山市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(340600, '淮北市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(340700, '铜陵市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(340800, '安庆市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(341000, '黄山市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(341100, '滁州市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(341200, '阜阳市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(341300, '宿州市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(341400, '巢湖市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(341500, '六安市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(341600, '亳州市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(341700, '池州市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(341800, '宣城市', 340000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(350000, '福建省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(350100, '福州市', 350000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(350200, '厦门市', 350000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(350300, '莆田市', 350000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(350400, '三明市', 350000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(350500, '泉州市', 350000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(350600, '漳州市', 350000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(350700, '南平市', 350000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(350800, '龙岩市', 350000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(350900, '宁德市', 350000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(360000, '江西省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(360100, '南昌市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(360200, '景德镇市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(360300, '萍乡市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(360400, '九江市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(360500, '新余市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(360600, '鹰潭市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(360700, '赣州市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(360800, '吉安市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(360900, '宜春市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(361000, '抚州市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(361100, '上饶市', 360000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(370000, '山东省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(370100, '济南市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(370200, '青岛市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(370300, '淄博市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(370400, '枣庄市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(370500, '东营市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(370600, '烟台市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(370700, '潍坊市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(370800, '济宁市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(370900, '泰安市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(371000, '威海市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(371100, '日照市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(371200, '莱芜市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(371300, '临沂市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(371400, '德州市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(371500, '聊城市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(371600, '滨州市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(371700, '荷泽市', 370000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(410000, '河南省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(410100, '郑州市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(410200, '开封市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(410300, '洛阳市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(410400, '平顶山市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(410500, '安阳市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(410600, '鹤壁市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(410700, '新乡市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(410800, '焦作市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(410900, '濮阳市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(411000, '许昌市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(411100, '漯河市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(411200, '三门峡市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(411300, '南阳市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(411400, '商丘市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(411500, '信阳市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(411600, '周口市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(411700, '驻马店市', 410000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(420000, '湖北省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(420100, '武汉市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(420200, '黄石市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(420300, '十堰市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(420500, '宜昌市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(420600, '襄樊市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(420700, '鄂州市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(420800, '荆门市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(420900, '孝感市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(421000, '荆州市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(421100, '黄冈市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(421200, '咸宁市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(421300, '随州市', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(422800, '恩施土家族苗族自治州', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(429000, '省直辖行政单位', 420000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(430000, '湖南省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(430100, '长沙市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(430200, '株洲市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(430300, '湘潭市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(430400, '衡阳市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(430500, '邵阳市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(430600, '岳阳市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(430700, '常德市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(430800, '张家界市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(430900, '益阳市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(431000, '郴州市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(431100, '永州市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(431200, '怀化市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(431300, '娄底市', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(433100, '湘西土家族苗族自治州', 430000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(440000, '广东省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(440100, '广州市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(440200, '韶关市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(440300, '深圳市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(440400, '珠海市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(440500, '汕头市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(440600, '佛山市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(440700, '江门市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(440800, '湛江市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(440900, '茂名市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(441200, '肇庆市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(441300, '惠州市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(441400, '梅州市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(441500, '汕尾市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(441600, '河源市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(441700, '阳江市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(441800, '清远市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(441900, '东莞市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(442000, '中山市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(445100, '潮州市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(445200, '揭阳市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(445300, '云浮市', 440000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(450000, '广西壮族自治区', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(450100, '南宁市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(450200, '柳州市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(450300, '桂林市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(450400, '梧州市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(450500, '北海市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(450600, '防城港市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(450700, '钦州市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(450800, '贵港市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(450900, '玉林市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(451000, '百色市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(451100, '贺州市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(451200, '河池市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(451300, '来宾市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(451400, '崇左市', 450000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(460000, '海南省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(460100, '海口市', 460000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(460200, '三亚市', 460000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(469000, '省直辖县级行政单位', 460000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(500000, '重庆市', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(500100, '市辖区', 500000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(500200, '县', 500000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(500300, '市', 500000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(510000, '四川省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(510100, '成都市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(510300, '自贡市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(510400, '攀枝花市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(510500, '泸州市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(510600, '德阳市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(510700, '绵阳市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(510800, '广元市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(510900, '遂宁市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(511000, '内江市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(511100, '乐山市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(511300, '南充市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(511400, '眉山市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(511500, '宜宾市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(511600, '广安市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(511700, '达州市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(511800, '雅安市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(511900, '巴中市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(512000, '资阳市', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(513200, '阿坝藏族羌族自治州', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(513300, '甘孜藏族自治州', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(513400, '凉山彝族自治州', 510000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(520000, '贵州省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(520100, '贵阳市', 520000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(520200, '六盘水市', 520000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(520300, '遵义市', 520000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(520400, '安顺市', 520000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(522200, '铜仁地区', 520000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(522300, '黔西南布依族苗族自治州', 520000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(522400, '毕节地区', 520000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(522600, '黔东南苗族侗族自治州', 520000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(522700, '黔南布依族苗族自治州', 520000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(530000, '云南省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(530100, '昆明市', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(530300, '曲靖市', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(530400, '玉溪市', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(530500, '保山市', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(530600, '昭通市', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(530700, '丽江市', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(530800, '思茅市', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(530900, '临沧市', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(532300, '楚雄彝族自治州', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(532500, '红河哈尼族彝族自治州', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(532600, '文山壮族苗族自治州', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(532800, '西双版纳傣族自治州', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(532900, '大理白族自治州', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(533100, '德宏傣族景颇族自治州', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(533300, '怒江傈僳族自治州', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(533400, '迪庆藏族自治州', 530000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(540000, '西藏自治区', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(540100, '拉萨市', 540000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(542100, '昌都地区', 540000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(542200, '山南地区', 540000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(542300, '日喀则地区', 540000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(542400, '那曲地区', 540000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(542500, '阿里地区', 540000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(542600, '林芝地区', 540000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(610000, '陕西省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(610100, '西安市', 610000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(610200, '铜川市', 610000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(610300, '宝鸡市', 610000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(610400, '咸阳市', 610000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(610500, '渭南市', 610000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(610600, '延安市', 610000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(610700, '汉中市', 610000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(610800, '榆林市', 610000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(610900, '安康市', 610000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(611000, '商洛市', 610000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(620000, '甘肃省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(620100, '兰州市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(620200, '嘉峪关市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(620300, '金昌市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(620400, '白银市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(620500, '天水市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(620600, '武威市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(620700, '张掖市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(620800, '平凉市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(620900, '酒泉市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(621000, '庆阳市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(621100, '定西市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(621200, '陇南市', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(622900, '临夏回族自治州', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(623000, '甘南藏族自治州', 620000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(630000, '青海省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(630100, '西宁市', 630000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(632100, '海东地区', 630000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(632200, '海北藏族自治州', 630000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(632300, '黄南藏族自治州', 630000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(632500, '海南藏族自治州', 630000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(632600, '果洛藏族自治州', 630000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(632700, '玉树藏族自治州', 630000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(632800, '海西蒙古族藏族自治州', 630000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(640000, '宁夏回族自治区', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(640100, '银川市', 640000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(640200, '石嘴山市', 640000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(640300, '吴忠市', 640000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(640400, '固原市', 640000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(640500, '中卫市', 640000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(650000, '新疆维吾尔自治区', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(650100, '乌鲁木齐市', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(650200, '克拉玛依市', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(652100, '吐鲁番地区', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(652200, '哈密地区', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(652300, '昌吉回族自治州', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(652700, '博尔塔拉蒙古自治州', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(652800, '巴音郭楞蒙古自治州', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(652900, '阿克苏地区', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(653000, '克孜勒苏柯尔克孜自治州', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(653100, '喀什地区', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(653200, '和田地区', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(654000, '伊犁哈萨克自治州', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(654200, '塔城地区', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(654300, '阿勒泰地区', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(659000, '省直辖行政单位', 650000, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(710000, '台湾省', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(810000, '香港特别行政区', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL),
	(820000, '澳门特别行政区', 0, 0, 1, 0, NULL, NULL, NULL, NULL, '2018-08-02 21:57:37', NULL);
/*!40000 ALTER TABLE `region` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
