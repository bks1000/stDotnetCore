/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2018-08-13 15:09:25
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `user`
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` varchar(36) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `phone` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('1', '张三', '168', '石家庄', '13211112333');
INSERT INTO `user` VALUES ('b27f23f4-ffde-414b-9026-5995110f53b0', 'ww', '200', '', '11111111111');
INSERT INTO `user` VALUES ('c3bf9cde-564c-4df7-87bc-22993477eb3b', 'li6', '666', '', '666');
INSERT INTO `user` VALUES ('dfa69147-ca63-43f0-a61f-d3ef69bed606', '李四', '20', '', '15033336666');
