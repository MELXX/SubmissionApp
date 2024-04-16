import 'package:flutter/material.dart';
import 'package:flutter_application_1/Config/DefaultVars.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Permission List',
      theme: ThemeData.dark(),
      home: PermissionListWidget(),
    );
  }
}

class PermissionListWidget extends StatefulWidget {
  @override
  _PermissionListWidgetState createState() => _PermissionListWidgetState();
}

class _PermissionListWidgetState extends State<PermissionListWidget> {
  List<Map<String, dynamic>> _permissions = [];

  @override
  void initState() {
    super.initState();
    _fetchPermissions();
  }

  Future<void> _fetchPermissions() async {
    final response = await http.get(Uri.parse(DefaultVars.baseurl+'/Permissions/list')); 

    if (response.statusCode == 200) {
      final List<dynamic> permissionsJson = jsonDecode(response.body);
      setState(() {
        _permissions = permissionsJson.map((permission) => Map<String, dynamic>.from(permission)).toList();
      });
    } else {
      throw Exception('Failed to load permissions');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Permission List'),
      ),
      body: _permissions.isEmpty
          ? Center(
              child: CircularProgressIndicator(),
            )
          : ListView.builder(
              itemCount: _permissions.length,
              itemBuilder: (context, index) {
                final permission = _permissions[index];
                return ListTile(
                  title: Text(permission['name']),
                );
              },
            ),
    );
  }
}
